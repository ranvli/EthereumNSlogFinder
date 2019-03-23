package com.ranvlicr.ens.screen.serverlist.adapter

import android.text.format.DateFormat
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.view.animation.AnimationUtils
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.ranvlicr.ens.R
import com.ranvlicr.ens.application.aux.ResExtractor
import com.ranvlicr.ens.screen.viewobject.ServerVo
import java.text.SimpleDateFormat
import java.util.*

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
class ServerVoAdapter(var dataSet: List<ServerVo>) : RecyclerView.Adapter<ServerVoAdapter.ServerVoViewHolder>() {

    private var lastPosition = -1

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ServerVoViewHolder {
        val view = LayoutInflater.from(parent.context).inflate(R.layout.item_server, parent, false)
        return ServerVoViewHolder(view)
    }

    override fun getItemCount(): Int {
        return dataSet.size
    }

    override fun onBindViewHolder(holder: ServerVoViewHolder, position: Int) {
        holder.bind(dataSet[position])
    }

    override fun onViewDetachedFromWindow(holder: ServerVoViewHolder) {
        super.onViewDetachedFromWindow(holder)
        holder.itemView.clearAnimation()
    }

    inner class ServerVoViewHolder(itemView: View) : RecyclerView.ViewHolder(itemView) {

        private lateinit var blockHash: TextView
        private lateinit var blockNumber: TextView
        private lateinit var numberOfTransactions: TextView
        private lateinit var timeStamp: TextView

        fun bind(toBind: ServerVo) {

            blockHash = itemView.findViewById(R.id.blockHash)
            blockHash.text = ResExtractor.getString(R.string.block_hash, toBind.blockHash)

            blockNumber = itemView.findViewById(R.id.blockNumber)
            blockNumber.text = ResExtractor.getString(R.string.block_number, toBind.blockNumber)

            numberOfTransactions = itemView.findViewById(R.id.noOfTransactions)
            numberOfTransactions.text = ResExtractor.getString(R.string.number_of_transactions, toBind.noOfTransactions)

            val sdf: SimpleDateFormat = if (DateFormat.is24HourFormat(itemView.context)) {
                SimpleDateFormat(ResExtractor.getString(R.string.date_format_24), Locale.US)
            } else {
                SimpleDateFormat(ResExtractor.getString(R.string.date_format), Locale.US)
            }

            timeStamp = itemView.findViewById(R.id.timeStamp)

            val dateString = sdf.format(toBind.timeStamp)
            timeStamp.text = ResExtractor.getString(R.string.time_stamp, dateString)

            val animation = AnimationUtils.loadAnimation(
                itemView.context,
                if (adapterPosition > lastPosition) R.anim.up_from_bottom else R.anim.down_from_top
            )

            itemView.startAnimation(animation)
            lastPosition = adapterPosition

        }

    }

}

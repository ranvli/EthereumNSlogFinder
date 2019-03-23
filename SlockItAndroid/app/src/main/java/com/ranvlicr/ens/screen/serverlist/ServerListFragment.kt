package com.ranvlicr.ens.screen.serverlist


import android.app.Dialog
import android.content.Context
import android.content.DialogInterface
import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.Toast
import androidx.annotation.StringRes
import androidx.appcompat.app.AlertDialog
import androidx.lifecycle.Observer
import androidx.lifecycle.ViewModelProviders
import androidx.recyclerview.widget.LinearLayoutManager
import com.google.android.material.snackbar.Snackbar
import com.ranvlicr.ens.R
import com.ranvlicr.ens.application.util.KeyboardUtil
import com.ranvlicr.ens.model.validator.EmptyValidator
import com.ranvlicr.ens.screen.base.BaseFragment
import com.ranvlicr.ens.screen.serverlist.adapter.ServerVoAdapter
import com.ranvlicr.ens.screen.serverlist.di.ServerListComponentHolder
import com.ranvlicr.ens.screen.viewobject.ViewObject
import kotlinx.android.synthetic.main.dialog_date_range_picker.*
import kotlinx.android.synthetic.main.fragment_server_list.*
import java.util.*
import javax.inject.Inject

class ServerListFragment : BaseFragment(), ServerListContract.View {

    companion object {

        @JvmStatic
        fun newInstance() = ServerListFragment()

    }

    @Inject
    protected lateinit var emptyValidator: EmptyValidator

    @Inject
    protected lateinit var viewModelFactory: ServerListViewModelFactory

    private lateinit var viewModel: ServerListContract.ViewModel

    private lateinit var serverAdapter: ServerVoAdapter

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)

        viewModel = ViewModelProviders.of(this, viewModelFactory).get(ServerListViewModel::class.java)

        viewModel.getServerLiveData().observe(this, Observer { viewObject ->

            when (viewObject.status) {

                ViewObject.Status.LOADING -> {
                    toggleProgressBar(false)
                }

                ViewObject.Status.ERROR -> {
                    toggleProgressBar(true)

                    showPromptDialog()

                    viewObject.error?.let {
                        showToastMessage(it.localizedMessage)
                    }

                }

                ViewObject.Status.SUCCESS -> {
                    toggleProgressBar(true)

                    val theList = viewObject.data
                    theList?.results?.let {

                        serverAdapter.dataSet = it
                        serverAdapter.notifyDataSetChanged()

                    } ?: kotlin.run {

                        if (serverAdapter.dataSet.isEmpty()) {
                            showPromptDialog()
                        }

                        showToastMessage(R.string.no_logs_found)
                    }


                }

            }

        })

        viewModel.getSortByDateEvent().observe(this, Observer {
            showDateRangeDialog()
        })

    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_server_list, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        setUpRecyclerView()

        showPromptDialog()

        radioAsc.setOnClickListener {
            viewModel.onSortAscendingClick()
        }

        radioDesc.setOnClickListener {
            viewModel.onSortDescendingClick()
        }

        buttonFilter.setOnClickListener {
            viewModel.onSortByDateClick()
        }

    }

    override fun onAttach(context: Context?) {
        super.onAttach(context)
        ServerListComponentHolder.getInstance().getComponent().inject(this)
    }

    override fun onDetach() {
        super.onDetach()
        ServerListComponentHolder.getInstance().unbindComponent()
    }

    override fun showMessage(@StringRes message: Int) {
        view?.let {
            Snackbar.make(it, message, Snackbar.LENGTH_SHORT).show()
        }
    }

    override fun showMessage(message: String) {
        view?.let {
            Snackbar.make(it, message, Snackbar.LENGTH_SHORT).show()
        }
    }

    override fun showToastMessage(@StringRes message: Int) {
        context?.let {
            Toast.makeText(it, message, Toast.LENGTH_SHORT).show()
        }
    }

    override fun showToastMessage(message: String) {
        context?.let {
            Toast.makeText(it, message, Toast.LENGTH_SHORT).show()
        }
    }

    override fun toggleProgressBar(hide: Boolean) {
        progressBar.visibility = if (hide) View.GONE else View.VISIBLE
    }

    private fun setUpRecyclerView() {

        context?.let { context ->

            serverAdapter = ServerVoAdapter(ArrayList())

            serverList.apply {
                layoutManager = LinearLayoutManager(context)
                setHasFixedSize(true)
                adapter = serverAdapter
            }

        }

    }

    private fun showPromptDialog() {

        context?.let { context ->

            val inflater = LayoutInflater.from(context)
            val view = inflater.inflate(R.layout.part_simple_edittext, null)

            val builder = AlertDialog.Builder(context).apply {
                setCancelable(false)
                setTitle(R.string.find_ens_logs)
                setPositiveButton(R.string.get_logs, null)
                setView(view)
            }

            val theInput: EditText = view.findViewById(R.id.domainNameInput)

            val theDialog = builder.create()
            theDialog.setOnShowListener {

                KeyboardUtil.showKeyboard(theInput)

                val theButton = theDialog.getButton(DialogInterface.BUTTON_POSITIVE)
                theButton?.setOnClickListener { view ->

                    val typedText = theInput.text.toString()
                    if (emptyValidator.isValid(typedText)) {

                        viewModel.searchDomainName(typedText)

                        KeyboardUtil.hideKeyboard(view)

                        theDialog.dismiss()

                    } else {
                        showToastMessage(emptyValidator.getDescription(getString(R.string.the_domain_name)))
                    }

                }

            }

            theDialog.show()

        }

    }

    private fun showDateRangeDialog() {
        context?.let {
            val aDialog = Dialog(it).apply {

                setContentView(R.layout.dialog_date_range_picker)

                val calendar = Calendar.getInstance()
                calendar.add(Calendar.DAY_OF_MONTH, -1)

                calendarView.date = calendar.timeInMillis

                calendarView.setOnDateChangeListener { view, year, month, dayOfMonth ->
                    timePicker.visibility = View.VISIBLE

                    calendar.set(Calendar.YEAR, year)
                    calendar.set(Calendar.MONTH, month)
                    calendar.set(Calendar.DAY_OF_MONTH, dayOfMonth)

                }

                timePicker.setOnTimeChangedListener { view, hourOfDay, minute ->
                    buttonApplyStartingDateTime.visibility = View.VISIBLE

                    calendar.set(Calendar.HOUR_OF_DAY, hourOfDay)
                    calendar.set(Calendar.MINUTE, minute)

                    scrollView.fullScroll(View.FOCUS_DOWN)

                }

                buttonApplyStartingDateTime.setOnClickListener {
                    viewModel.onApplyStartingDateTimeClick(calendar.time.time)
                    dismiss()
                }

            }

            aDialog.show()
            aDialog.window?.attributes = getCorrectLayoutParams(aDialog)

        }

    }

}

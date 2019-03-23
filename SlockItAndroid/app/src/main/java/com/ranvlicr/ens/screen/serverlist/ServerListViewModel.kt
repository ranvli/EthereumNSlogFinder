package com.ranvlicr.ens.screen.serverlist

import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import com.ranvlicr.ens.application.aux.SingleLiveEvent
import com.ranvlicr.ens.model.dataobject.so.ServerListSO
import com.ranvlicr.ens.model.usecase.ServerUseCase
import com.ranvlicr.ens.screen.viewobject.ServerListVo
import com.ranvlicr.ens.screen.viewobject.ServerListVoMapper
import com.ranvlicr.ens.screen.viewobject.ServerVo
import com.ranvlicr.ens.screen.viewobject.ViewObject
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.disposables.Disposable
import io.reactivex.schedulers.Schedulers
import java.util.*
import kotlin.collections.ArrayList

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 */
class ServerListViewModel(private val serverUseCase: ServerUseCase) : ViewModel(), ServerListContract.ViewModel {

    private var serversLiveData: MutableLiveData<ViewObject<ServerListVo>>? = MutableLiveData()
    private var sortByDateEvent: SingleLiveEvent<Void>? = SingleLiveEvent()

    private var serversDisposable: Disposable? = null

    private var typedText: String? = ""

    override fun getSortByDateEvent(): SingleLiveEvent<Void> {

        return sortByDateEvent?.let {
            return@let it
        } ?: kotlin.run {
            return@run SingleLiveEvent<Void>()
        }

    }

    override fun getServerLiveData(): MutableLiveData<ViewObject<ServerListVo>> {

        return serversLiveData?.let {
            return@let it
        } ?: kotlin.run {
            return@run MutableLiveData<ViewObject<ServerListVo>>()
        }

    }

    override fun searchDomainName(typedText: String) {
        this.typedText = typedText

        serversLiveData?.value = ViewObject.loading()

        val aCalendar = Calendar.getInstance()
        aCalendar.time = Date(System.currentTimeMillis())
        aCalendar.add(Calendar.DAY_OF_YEAR, -1)

        serversDisposable = serverUseCase.getServerList(
            ServerListSO.builder()
                .any(typedText)
                .from((aCalendar.timeInMillis / 1000).toString())
                .build()
        )
            .subscribeOn(Schedulers.io())
            .observeOn(AndroidSchedulers.mainThread())
            .map(ServerListVoMapper::fromDto)
            .subscribe(
                { serversLiveData?.value = ViewObject.success(it) },
                { serversLiveData?.value = ViewObject.error(it) }
            )

    }

    override fun onSortAscendingClick() {
        val toOrder = serversLiveData?.value?.data

        serversLiveData?.value = ViewObject.loading()
        toOrder?.let { serverListVo ->
            val descList = ArrayList(serverListVo.results).sortedWith(compareBy {
                it.timeStamp })

            serversLiveData?.value = ViewObject.success(ServerListVo.builder().results(descList).build())

        }
    }

    override fun onSortDescendingClick() {
        val toOrder = serversLiveData?.value?.data

        serversLiveData?.value = ViewObject.loading()
        toOrder?.let { serverListVo ->
            val descList = ArrayList(serverListVo.results).sortedWith(compareByDescending<ServerVo> {
                it.timeStamp })

            serversLiveData?.value = ViewObject.success(ServerListVo.builder().results(descList).build())

        }

    }

    override fun onSortByDateClick() {
        sortByDateEvent?.call()
    }

    override fun onApplyStartingDateTimeClick(time: Long) {
        serversLiveData?.value = ViewObject.loading()

        serversDisposable = serverUseCase.getServerList(
            ServerListSO.builder()
                .any(typedText)
                .from((time / 1000).toString())
                .build()
        )
            .subscribeOn(Schedulers.io())
            .observeOn(AndroidSchedulers.mainThread())
            .map(ServerListVoMapper::fromDto)
            .subscribe(
                { serversLiveData?.value = ViewObject.success(it) },
                { serversLiveData?.value = ViewObject.error(it) }
            )

    }

    override fun onCleared() {
        super.onCleared()

        sortByDateEvent = null
        typedText = null

        serversDisposable?.dispose()

    }

}

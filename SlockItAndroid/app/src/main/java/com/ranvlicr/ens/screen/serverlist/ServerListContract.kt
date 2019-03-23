package com.ranvlicr.ens.screen.serverlist

import androidx.lifecycle.MutableLiveData
import com.ranvlicr.ens.application.aux.SingleLiveEvent
import com.ranvlicr.ens.screen.base.MessageView
import com.ranvlicr.ens.screen.base.ProgressView
import com.ranvlicr.ens.screen.base.ToastMessageView
import com.ranvlicr.ens.screen.viewobject.ServerListVo
import com.ranvlicr.ens.screen.viewobject.ViewObject

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 * .
 */
interface ServerListContract {

    interface ViewModel {

        fun getServerLiveData(): MutableLiveData<ViewObject<ServerListVo>>

        fun getSortByDateEvent(): SingleLiveEvent<Void>

        fun searchDomainName(typedText: String)

        fun onSortAscendingClick()

        fun onSortDescendingClick()

        fun onSortByDateClick()

        fun onApplyStartingDateTimeClick(time: Long)

    }

    interface View : MessageView, ToastMessageView, ProgressView

    interface Router {

    }

}

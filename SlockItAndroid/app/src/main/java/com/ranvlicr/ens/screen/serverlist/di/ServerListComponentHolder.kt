package com.ranvlicr.ens.screen.serverlist.di

import com.ranvlicr.ens.application.di.base.BaseComponentHolder

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 */
class ServerListComponentHolder private constructor() : BaseComponentHolder<ServerListComponent>() {

    companion object {

        private var INSTANCE: ServerListComponentHolder? = null

        @JvmStatic
        fun getInstance(): ServerListComponentHolder {

            if (null == INSTANCE) {
                INSTANCE = ServerListComponentHolder()
            }
            return INSTANCE!!

        }

    }

}

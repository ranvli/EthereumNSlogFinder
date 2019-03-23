package com.ranvlicr.ens.application.di

import com.ranvlicr.ens.application.di.base.BaseComponentHolder

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 * .
 */
class AppComponentHolder private constructor() : BaseComponentHolder<AppComponent>() {

    companion object {

        private var INSTANCE: AppComponentHolder? = null

        @JvmStatic
        fun getInstance(): AppComponentHolder {
            if (null == INSTANCE) {
                INSTANCE = AppComponentHolder()
            }
            return INSTANCE!!
        }

    }

}

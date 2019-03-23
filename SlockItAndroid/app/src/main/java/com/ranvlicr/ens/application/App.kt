package com.ranvlicr.ens.application

import android.app.Application
import com.ranvlicr.ens.application.aux.ResExtractor
import com.ranvlicr.ens.application.di.AppComponentHolder
import com.ranvlicr.ens.application.di.AppModule
import com.ranvlicr.ens.application.di.DaggerAppComponent

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 */
class App : Application() {

    override fun onCreate() {
        super.onCreate()

        ResExtractor.init(this)

        initAppComponent()

    }

    private fun initAppComponent() {

        AppComponentHolder.getInstance().bindComponent(
            DaggerAppComponent.builder()
                .appModule(AppModule(this))
                .build()
        )

    }

}

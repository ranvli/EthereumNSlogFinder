package com.ranvlicr.ens.application.di

import android.content.Context
import com.ranvlicr.ens.application.App
import com.ranvlicr.ens.model.dataprovider.ServerListDataProvider
import com.ranvlicr.ens.model.validator.EmptyValidator
import dagger.Component
import javax.inject.Singleton

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 */
@Singleton
@Component(modules = [AppModule::class, RetrofitModule::class, DataSourceModule::class, DataProviderModule::class])
interface AppComponent {

    fun inject(app: App)

    fun provideContext(): Context

    fun provideServerListDataProvider(): ServerListDataProvider

    fun provideEmptyValidator(): EmptyValidator

}

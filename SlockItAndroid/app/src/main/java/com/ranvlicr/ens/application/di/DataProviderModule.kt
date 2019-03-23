package com.ranvlicr.ens.application.di

import com.ranvlicr.ens.model.dataprovider.ServerListDataProvider
import com.ranvlicr.ens.model.dataprovider.ServerListDataProviderImpl
import com.ranvlicr.ens.model.datasource.ServerListDataSource
import dagger.Module
import dagger.Provides
import javax.inject.Singleton

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
@Module
class DataProviderModule {

    @Provides
    @Singleton
    fun provideServerListDataProvider(dataSource: ServerListDataSource): ServerListDataProvider {
        return ServerListDataProviderImpl(dataSource)
    }

}

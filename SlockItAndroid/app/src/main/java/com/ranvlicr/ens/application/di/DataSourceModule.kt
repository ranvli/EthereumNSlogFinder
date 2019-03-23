package com.ranvlicr.ens.application.di

import com.ranvlicr.ens.application.rest.ServerRestClient
import com.ranvlicr.ens.model.datasource.ServerListDataSource
import com.ranvlicr.ens.model.datasource.ServerListRestDataSource
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
class DataSourceModule {

    @Provides
    @Singleton
    fun provideServerListDataSource(restClient: ServerRestClient): ServerListDataSource {
        return ServerListRestDataSource(restClient)
    }

}

package com.ranvlicr.ens.screen.serverlist.di

import com.ranvlicr.ens.model.dataprovider.ServerListDataProvider
import com.ranvlicr.ens.model.usecase.ServerUseCase
import com.ranvlicr.ens.screen.serverlist.ServerListViewModelFactory
import dagger.Module
import dagger.Provides

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 * .
 */
@Module
class ServerListModule {

    @Provides
    fun provideServerUseCase(dataProvider: ServerListDataProvider): ServerUseCase {
        return ServerUseCase(dataProvider)
    }

    @Provides
    fun provideServerListViewModelFactory(useCase: ServerUseCase): ServerListViewModelFactory {
        return ServerListViewModelFactory(useCase)
    }

}

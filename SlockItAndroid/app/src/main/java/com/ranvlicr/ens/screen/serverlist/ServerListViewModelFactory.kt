package com.ranvlicr.ens.screen.serverlist

import androidx.lifecycle.ViewModel
import androidx.lifecycle.ViewModelProvider
import com.ranvlicr.ens.model.usecase.ServerUseCase

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 */
class ServerListViewModelFactory(private val serverUseCase:ServerUseCase) : ViewModelProvider.Factory {

    override fun <T : ViewModel?> create(modelClass: Class<T>): T {
        return ServerListViewModel(serverUseCase) as T
    }

}
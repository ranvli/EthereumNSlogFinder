package com.ranvlicr.ens.model.usecase

import com.google.gson.GsonBuilder
import com.ranvlicr.ens.model.dataobject.dto.ServerListDto
import com.ranvlicr.ens.model.dataobject.so.ServerListSO
import com.ranvlicr.ens.model.dataprovider.ServerListDataProvider
import io.reactivex.Flowable

/**
 * ENS
 *
 * Created by Randall Vargas on 3/13/19.
 *
 */
class ServerUseCase(private val dataProvider: ServerListDataProvider) {

    private val gson = GsonBuilder().create()

    fun getServerList(data: ServerListSO): Flowable<ServerListDto> {
        return dataProvider.getServerList(gson.toJson(data))
    }

}

package com.ranvlicr.ens.model.datasource

import com.ranvlicr.ens.application.rest.ServerRestClient
import com.ranvlicr.ens.model.dataobject.dto.ServerListDto
import io.reactivex.Flowable

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
class ServerListRestDataSource(private val client: ServerRestClient) : ServerListDataSource {

    override fun gerServerList(jsonParams: String): Flowable<ServerListDto> {
        return client.getServerList(jsonParams)
    }

}

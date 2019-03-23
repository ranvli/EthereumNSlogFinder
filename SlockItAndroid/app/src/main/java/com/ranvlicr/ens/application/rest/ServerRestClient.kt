package com.ranvlicr.ens.application.rest

import com.ranvlicr.ens.model.dataobject.dto.ServerListDto
import io.reactivex.Flowable
import retrofit2.http.GET
import retrofit2.http.Query

/**
 * ENS
 *
 * Created by Randall Vargas on 3/13/19.
 *
 */

private const val RESOURCE_ROOT = "GetHistoryAny"

interface ServerRestClient {

    @GET(RESOURCE_ROOT)
    fun getServerList(@Query("p") jsonParams: String): Flowable<ServerListDto>

}

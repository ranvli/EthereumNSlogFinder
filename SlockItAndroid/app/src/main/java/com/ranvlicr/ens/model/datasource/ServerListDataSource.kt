package com.ranvlicr.ens.model.datasource

import com.ranvlicr.ens.model.dataobject.dto.ServerListDto
import io.reactivex.Flowable

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
interface ServerListDataSource {

    fun gerServerList(jsonParams: String): Flowable<ServerListDto>

}

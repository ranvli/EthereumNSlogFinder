package com.ranvlicr.ens.model.dataprovider

import com.ranvlicr.ens.model.dataobject.dto.ServerListDto
import io.reactivex.Flowable

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
interface ServerListDataProvider {

    fun getServerList(jsonParams: String): Flowable<ServerListDto>

}

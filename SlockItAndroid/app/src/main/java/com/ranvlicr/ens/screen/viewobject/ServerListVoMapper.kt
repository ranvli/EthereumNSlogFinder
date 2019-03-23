package com.ranvlicr.ens.screen.viewobject

import com.ranvlicr.ens.model.dataobject.dto.ServerDto
import com.ranvlicr.ens.model.dataobject.dto.ServerListDto

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
object ServerListVoMapper {

    @JvmStatic
    fun fromDto(value: ServerListDto): ServerListVo {
        return ServerListVo.builder()
            .results(fromListDto(value.results))
            .build()
    }

    @JvmStatic
    fun fromListDto(value: ArrayList<ServerDto>?): ArrayList<ServerVo> {

        value?.let {
            val list = ArrayList<ServerVo>()
            list.addAll(ServerVoMapper.fromList(it))
            return list
        }

        return ArrayList()

    }

}

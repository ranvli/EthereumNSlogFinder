package com.ranvlicr.ens.screen.viewobject

import com.ranvlicr.ens.model.dataobject.dto.ServerDto

/**
 * ENS
 *
 * Created by Randall Vargas on 3/13/19.
 *
 */
object ServerVoMapper {

    @JvmStatic
    fun fromDto(value: ServerDto): ServerVo {
        return ServerVo.builder()
            .blockHash(value.blockHash)
            .blockNumber(value.blockNumber)
            .noOfTransactions(value.noOfTransactions)
            .timeStamp(value.timeStamp?.times(1000))
            .build()
    }

    @JvmStatic
    fun fromList(value: List<ServerDto>): List<ServerVo> {
        val toReturn = mutableListOf<ServerVo>()

        for (serverDto in value) {
            toReturn.add(fromDto(serverDto))
        }

        return toReturn

    }

}

package com.ranvlicr.ens.model.dataobject.dto

import com.google.gson.annotations.SerializedName

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 */
data class ServerDto(
    @SerializedName("BlockHash") val blockHash: String?,
    @SerializedName("BlockNumber") val blockNumber: Long?,
    @SerializedName("NumberOfTransactions") val noOfTransactions: Long?,
    @SerializedName("TimeStamp") val timeStamp: Long?
)

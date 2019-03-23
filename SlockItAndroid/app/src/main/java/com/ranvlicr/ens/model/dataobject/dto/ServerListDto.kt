package com.ranvlicr.ens.model.dataobject.dto

import com.google.gson.annotations.SerializedName

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
data class ServerListDto(@SerializedName("GetHistoryAnyResult") val results: ArrayList<ServerDto>?)

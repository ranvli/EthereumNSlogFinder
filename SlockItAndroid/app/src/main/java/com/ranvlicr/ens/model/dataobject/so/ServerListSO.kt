package com.ranvlicr.ens.model.dataobject.so

import com.google.gson.annotations.SerializedName

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
class ServerListSO private constructor(
    @SerializedName("Any") val any: String,
    @SerializedName("From") val from: String?
) {

    companion object {

        @JvmStatic
        fun builder() = Builder()

    }

    class Builder {

        private var any = ""
        private var from: String? = null

        fun any(value: String?) = apply {
            if (null != value) {
                this.any = value
            }
        }

        fun from(value: String?) = apply {
            if (null != value) {
                this.from = value
            }
        }

        fun build() = ServerListSO(any, from)

    }

}

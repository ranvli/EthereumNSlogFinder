package com.ranvlicr.ens.screen.viewobject

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
class ServerListVo private constructor(val results: List<ServerVo>) {

    companion object {

        @JvmStatic
        fun builder() = Builder()

    }

    class Builder {

        private var results = listOf<ServerVo>()

        fun results(value: List<ServerVo>?) = apply {
            if (null != value) {
                this.results = value
            }
        }

        fun build() = ServerListVo(results)

    }

}

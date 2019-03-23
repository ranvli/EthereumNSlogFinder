package com.ranvlicr.ens.application.rest.config

/**
 * ENS
 *
 * Created by Randall Vargas on 3/13/19.
 *
 */
class SimpleServerEndpoint(builder: Builder): BaseServerEndpoint(builder.host, builder.path, builder.version) {

    class Builder {
        var host: String = ""
        var path: String = ""
        var version: String = ""

        fun host(value: String): Builder {
            this.host = value
            return this
        }

        fun path(value: String): Builder {
            this.path = value
            return this
        }

        fun version(value: String): Builder {
            this.version = value
            return this
        }

        fun build(): ServerEndpoint {
            return SimpleServerEndpoint(this)
        }

    }

}

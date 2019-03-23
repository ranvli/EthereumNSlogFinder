package com.ranvlicr.ens.application.rest.config

import android.text.TextUtils

/**
 * ENS
 *
 * Created by Randall Vargas on 3/13/19.
 *
 */
open class BaseServerEndpoint(private val host: String, private val path: String, private val api: String) :
    ServerEndpoint {

    override fun getUrl(): String {
        val builder = StringBuilder()
        builder.append(host)
        if (!TextUtils.isEmpty(path)) {
            builder.append("/").append(path)
        }
        if (!TextUtils.isEmpty(api)) {
            builder.append("/").append(api)
        }
        builder.append('/')
        return builder.toString()
    }

    override fun toString(): String {
        return "BaseServerEndpoint(host='$host', path='$path', api='$api')"
    }

}

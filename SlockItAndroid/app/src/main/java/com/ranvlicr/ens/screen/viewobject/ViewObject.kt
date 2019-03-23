package com.ranvlicr.ens.screen.viewobject

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 * .
 */
class ViewObject<T> private constructor(
    val status: Status,
    val data: T?,
    val error: Throwable?
) {

    companion object {
        @JvmStatic
        fun <T> loading() = ViewObject<T>(Status.LOADING, null, null)

        @JvmStatic
        fun <T> success(data: T?) = ViewObject(Status.SUCCESS, data, null)

        @JvmStatic
        fun <T> error(error: Throwable?) = ViewObject<T>(Status.ERROR, null, error)

    }

    enum class Status {
        LOADING,
        SUCCESS,
        ERROR
    }

}

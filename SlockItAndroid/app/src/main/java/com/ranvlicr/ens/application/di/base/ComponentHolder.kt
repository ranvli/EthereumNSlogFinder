package com.ranvlicr.ens.application.di.base

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 * .
 */
interface ComponentHolder<T> {

    fun bindComponent(component: T)

    fun unbindComponent()

    fun getComponent(): T

}

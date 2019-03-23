package com.ranvlicr.ens.application.di.base

import com.ranvlicr.ens.R
import com.ranvlicr.ens.application.aux.ResExtractor
import java.lang.IllegalStateException

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 */
open class BaseComponentHolder<T> : ComponentHolder<T> {

    private var component: T? = null

    override fun bindComponent(component: T) {
        this.component = component
    }

    override fun unbindComponent() {
        this.component = null
    }

    override fun getComponent(): T {
        if (null == component) {
            throw IllegalStateException(ResExtractor.getString(R.string.component_must_be_bound))
        }

        return component!!
    }

}

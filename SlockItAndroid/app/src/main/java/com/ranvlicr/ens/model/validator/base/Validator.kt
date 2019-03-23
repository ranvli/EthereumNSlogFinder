package com.ranvlicr.ens.model.validator.base

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 * .
 */
interface Validator<T> {

    fun isValid(value: T): Boolean

    fun getDescription(emptyValue: String?): String

}

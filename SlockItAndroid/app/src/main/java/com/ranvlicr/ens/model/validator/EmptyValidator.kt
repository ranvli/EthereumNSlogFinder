package com.ranvlicr.ens.model.validator

import com.ranvlicr.ens.R
import com.ranvlicr.ens.application.aux.ResExtractor
import com.ranvlicr.ens.model.validator.base.Validator

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 * .
 */
class EmptyValidator : Validator<String> {

    override fun isValid(value: String): Boolean {
        return value.isNotEmpty() && value.isNotBlank()
    }

    override fun getDescription(emptyValue: String?): String {

        var toReturn = ""

        emptyValue?.let {
            toReturn = ResExtractor.getString(R.string.field_must_not_be_empty, emptyValue)
        } ?: kotlin.run {
            toReturn = ResExtractor.getString(R.string.field_must_not_be_empty_no_place_holder)
        }

        return toReturn

    }

}
package com.ranvlicr.ens.model.validator

import com.ranvlicr.ens.R
import com.ranvlicr.ens.application.aux.ResExtractor
import java.util.*

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 * .
 */
class DateRangeValidator {

    fun isValid(startDate: Long, endDate: Long): Boolean {
        val startTime = Date(startDate)
        val endTime = Date(endDate)
        return startTime.before(endTime)
    }

    fun getDescription(): String {
        return ResExtractor.getString(R.string.start_time_should_not_be_greater)
    }

}
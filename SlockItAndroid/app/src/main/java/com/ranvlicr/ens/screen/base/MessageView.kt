package com.ranvlicr.ens.screen.base

import androidx.annotation.StringRes

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 */
interface MessageView {

    fun showMessage(@StringRes message: Int)

    fun showMessage(message: String)

}

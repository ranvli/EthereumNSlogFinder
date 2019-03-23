package com.ranvlicr.ens.screen.base

import androidx.annotation.StringRes

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 */
interface ToastMessageView {

    fun showToastMessage(@StringRes message: Int)

    fun showToastMessage(message: String)

}

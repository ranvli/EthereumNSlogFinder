package com.ranvlicr.ens.application.util

import android.content.Context
import android.view.View
import android.view.inputmethod.InputMethodManager

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
object KeyboardUtil {

    @JvmStatic
    fun showKeyboard(editTextView: View) {
        editTextView.requestFocus()

        val context = editTextView.context
        val inputMethodManager = context.getSystemService(Context.INPUT_METHOD_SERVICE) as InputMethodManager

        inputMethodManager.showSoftInput(editTextView, InputMethodManager.SHOW_IMPLICIT)
    }

    @JvmStatic
    fun hideKeyboard(anchorView: View) {
        val context = anchorView.context
        val inputMethodManager = context.getSystemService(Context.INPUT_METHOD_SERVICE) as InputMethodManager
        val windowToken = anchorView.windowToken

        inputMethodManager.hideSoftInputFromWindow(windowToken, InputMethodManager.HIDE_NOT_ALWAYS)
    }


}

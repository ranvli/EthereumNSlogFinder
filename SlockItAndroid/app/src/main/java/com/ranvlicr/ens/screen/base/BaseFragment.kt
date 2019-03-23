package com.ranvlicr.ens.screen.base

import android.app.Dialog
import android.view.WindowManager
import androidx.fragment.app.Fragment

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
open class BaseFragment : Fragment() {

    protected fun getCorrectLayoutParams(dialog: Dialog): WindowManager.LayoutParams? {

        dialog.window?.let {
            val params = WindowManager.LayoutParams()

            params.copyFrom(it.attributes)
            params.width = WindowManager.LayoutParams.MATCH_PARENT
            params.height = WindowManager.LayoutParams.WRAP_CONTENT

            return params
        }

        return null

    }

}

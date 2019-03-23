package com.ranvlicr.ens.application.util

import android.app.Activity
import android.content.Context
import android.content.Intent
import android.os.Bundle
import androidx.annotation.IdRes
import androidx.appcompat.app.AppCompatActivity

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 * .
 */
object RoutingUtil {

    private val TAG = RoutingUtil::class.java.simpleName
    val BUNDLE = TAG + "_BUNDLE"

    @JvmStatic
    fun startActivity(context: Context, toActivityClass: Class<out Activity>, activityFlags: Int?,
                      bundle: Bundle?) {

        val intent = Intent(context, toActivityClass)

        if (activityFlags != null) {
            intent.flags = activityFlags
        }
        if (bundle != null) {
            intent.putExtra(BUNDLE, bundle)
        }
        context.startActivity(intent)
    }

    @JvmStatic
    fun startActivity(fromActivity: Activity,
                      toActivityClass: Class<out Activity>,
                      activityFlags: Int?,
                      bundle: Bundle?,
                      finishFromActivity: Boolean) {

        val intent = Intent(fromActivity, toActivityClass)

        if (activityFlags != null) {
            intent.flags = activityFlags
        }

        if (bundle != null) {
            intent.putExtra(BUNDLE, bundle)
        }

        fromActivity.startActivity(intent)

        if (finishFromActivity) {
            fromActivity.finish()
        }
    }

    @JvmStatic
    fun startActivity(fromActivity: Activity,
                      toActivityClass: Class<out Activity>) {

        startActivity(fromActivity, toActivityClass, null, null, false)
    }

    @JvmStatic
    fun startActivity(fromActivity: Activity,
                      toActivityClass: Class<out Activity>,
                      activityFlags: Int?) {
        startActivity(fromActivity, toActivityClass, activityFlags, null, false)
    }

    @JvmStatic
    fun startActivity(fromActivity: Activity,
                      toActivityClass: Class<out Activity>,
                      bundle: Bundle?) {
        startActivity(fromActivity, toActivityClass, null, bundle, false)
    }

    @JvmStatic
    fun startActivity(fromActivity: Activity,
                      toActivityClass: Class<out Activity>,
                      finishFromActivity: Boolean) {
        startActivity(fromActivity, toActivityClass, null, null, finishFromActivity)
    }

    @JvmStatic
    fun startForResult(fromActivity: Activity,
                       toActivityClass: Class<out Activity>,
                       requestCode: Int) {
        startForResult(fromActivity, toActivityClass, null, null, requestCode)
    }

    @JvmStatic
    fun startForResult(fromActivity: Activity,
                       toActivityClass: Class<out Activity>,
                       activityFlags: Int?,
                       requestCode: Int) {
        startForResult(fromActivity, toActivityClass, activityFlags, null, requestCode)
    }

    @JvmStatic
    fun startForResult(fromActivity: Activity,
                       toActivityClass: Class<out Activity>,
                       bundle: Bundle?,
                       requestCode: Int) {
        startForResult(fromActivity, toActivityClass, null, bundle, requestCode)
    }

    @JvmStatic
    fun startForResult(fromActivity: Activity,
                       toActivityClass: Class<out Activity>,
                       activityFlags: Int?,
                       bundle: Bundle?,
                       requestCode: Int) {
        val intent = Intent(fromActivity, toActivityClass)

        if (activityFlags != null) {
            intent.flags = activityFlags
        }

        if (bundle != null) {
            intent.putExtra(BUNDLE, bundle)
        }

        fromActivity.startActivityForResult(intent, requestCode)
    }

    @JvmStatic
    fun showFragment(activity: AppCompatActivity,
                     @IdRes containerViewId: Int,
                     fragment: androidx.fragment.app.Fragment) {
        showFragment(activity, null, containerViewId, fragment, false)
    }

    @JvmStatic
    fun showFragment(activity: AppCompatActivity,
                     savedInstanceState: Bundle?,
                     @IdRes containerViewId: Int,
                     fragment: androidx.fragment.app.Fragment) {
        showFragment(activity, savedInstanceState, containerViewId, fragment, false)
    }

    @JvmStatic
    fun showFragment(activity: AppCompatActivity,
                     savedInstanceState: Bundle?,
                     @IdRes containerViewId: Int,
                     fragment: androidx.fragment.app.Fragment,
                     addToBackStack: Boolean) {
        if (savedInstanceState != null) {
            // After recreation. No action is required.
            return
        }

        val ft = activity.supportFragmentManager.beginTransaction()
        val fragmentTag = fragment.javaClass.name

        ft.replace(containerViewId, fragment, fragmentTag)

        if (addToBackStack) {
            ft.addToBackStack(fragmentTag)
        }

        ft.commit()
    }


}

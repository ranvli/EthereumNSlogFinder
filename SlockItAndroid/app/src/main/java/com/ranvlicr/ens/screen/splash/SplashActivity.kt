package com.ranvlicr.ens.screen.splash

import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import com.ranvlicr.ens.application.util.RoutingUtil
import com.ranvlicr.ens.screen.serverlist.ServerListActivity

class SplashActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        RoutingUtil.startActivity(
            this, ServerListActivity::class.java, null,
            null, true
        )

    }

}

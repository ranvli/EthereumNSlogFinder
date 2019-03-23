package com.ranvlicr.ens.screen.serverlist

import android.app.SearchManager
import android.content.Context
import android.os.Bundle
import android.view.Menu
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.widget.SearchView
import com.ranvlicr.ens.R
import com.ranvlicr.ens.application.di.AppComponentHolder
import com.ranvlicr.ens.application.util.RoutingUtil
import com.ranvlicr.ens.screen.serverlist.di.DaggerServerListComponent
import com.ranvlicr.ens.screen.serverlist.di.ServerListComponentHolder

class ServerListActivity : AppCompatActivity() {

    private lateinit var serverListFragment: ServerListFragment

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_server_list)

        ServerListComponentHolder.getInstance().bindComponent(
            DaggerServerListComponent.builder()
                .appComponent(AppComponentHolder.getInstance().getComponent())
                .build()
        )

        serverListFragment = ServerListFragment.newInstance()

        RoutingUtil.showFragment(
            this, null,
            R.id.container, serverListFragment, false
        )

    }

}

package com.ranvlicr.ens.screen.serverlist.di

import com.ranvlicr.ens.application.di.AppComponent
import com.ranvlicr.ens.application.di.scope.ActivityScope
import com.ranvlicr.ens.screen.serverlist.ServerListActivity
import com.ranvlicr.ens.screen.serverlist.ServerListFragment
import dagger.Component

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 */
@ActivityScope
@Component(dependencies = [AppComponent::class], modules = [ServerListModule::class])
interface ServerListComponent {

    fun inject(fragment: ServerListFragment)

}

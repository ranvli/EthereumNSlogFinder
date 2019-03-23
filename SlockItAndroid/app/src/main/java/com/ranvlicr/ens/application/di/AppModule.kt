package com.ranvlicr.ens.application.di

import android.content.Context
import com.ranvlicr.ens.application.App
import com.ranvlicr.ens.model.validator.EmptyValidator
import dagger.Module
import dagger.Provides
import javax.inject.Singleton

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 * .
 */
@Module
class AppModule(private val app: App) {

    @Provides
    @Singleton
    fun provideContext(): Context = app

    @Provides
    @Singleton
    fun provideEmptyValidator(): EmptyValidator {
        return EmptyValidator()
    }

}

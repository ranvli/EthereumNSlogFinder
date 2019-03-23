package com.ranvlicr.ens.application.di

import android.content.Context
import com.google.gson.Gson
import com.google.gson.GsonBuilder
import com.ranvlicr.ens.R
import com.ranvlicr.ens.application.rest.ServerRestClient
import com.ranvlicr.ens.application.rest.config.ServerEndpoint
import com.ranvlicr.ens.application.rest.config.SimpleServerEndpoint
import dagger.Module
import dagger.Provides
import okhttp3.OkHttpClient
import okhttp3.logging.HttpLoggingInterceptor
import retrofit2.Retrofit
import retrofit2.adapter.rxjava2.RxJava2CallAdapterFactory
import retrofit2.converter.gson.GsonConverterFactory
import java.util.concurrent.TimeUnit
import javax.inject.Singleton

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
@Module
class RetrofitModule {

    @Provides
    @Singleton
    fun provideServerRestClient(retrofit: Retrofit): ServerRestClient {
        return retrofit.create(ServerRestClient::class.java)
    }

    @Provides
    @Singleton
    fun provideGson(): Gson {
        return GsonBuilder().create()
    }

    @Provides
    @Singleton
    protected fun provideHttpLoggingInterceptor(): HttpLoggingInterceptor {
        val loggingInterceptor = HttpLoggingInterceptor()
        loggingInterceptor.level = HttpLoggingInterceptor.Level.BODY
        return loggingInterceptor
    }

    @Provides
    @Singleton
    fun provideOkHttpClient(context: Context, loggingInterceptor: HttpLoggingInterceptor): OkHttpClient {
        val connectTimeout = context.resources.getInteger(R.integer.connect_timeout_seconds).toLong()
        val readTimeout = context.resources.getInteger(R.integer.read_timeout_seconds).toLong()
        val writeTimeout = context.resources.getInteger(R.integer.write_timeout_seconds).toLong()

        return OkHttpClient.Builder()
            .retryOnConnectionFailure(true)
            .connectTimeout(connectTimeout, TimeUnit.SECONDS)
            .readTimeout(readTimeout, TimeUnit.SECONDS)
            .writeTimeout(writeTimeout, TimeUnit.SECONDS)
            .addInterceptor(loggingInterceptor)
            .build()

    }

    @Provides
    @Singleton
    fun provideServerEndPoint(context: Context): ServerEndpoint {
        val baseUrl = context.getString(R.string.url_base)
        val path = context.getString(R.string.api)
        val api2 = context.getString(R.string.api_2)

        return SimpleServerEndpoint.Builder()
            .host(baseUrl)
            .path(path)
            .version(api2)
            .build()

    }

    @Singleton
    @Provides
    fun provideRetrofit(serverEndpoint: ServerEndpoint, gson: Gson, client: OkHttpClient): Retrofit {
        return Retrofit.Builder()
            .baseUrl(serverEndpoint.getUrl())
            .addCallAdapterFactory(RxJava2CallAdapterFactory.create())
            .addConverterFactory(GsonConverterFactory.create(gson))
            .client(client)
            .build()
    }

}

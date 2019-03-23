package com.ranvlicr.ens.model.dataprovider

import com.ranvlicr.ens.model.dataobject.dto.ServerListDto
import com.ranvlicr.ens.model.datasource.ServerListDataSource
import io.reactivex.Flowable
import java.util.concurrent.atomic.AtomicReference

/**
 * ENS
 *
 * Created by Randall Vargas on 3/18/19.
 *
 */
class ServerListDataProviderImpl(private val dataSource: ServerListDataSource) : ServerListDataProvider {

    override fun getServerList(jsonParams: String): Flowable<ServerListDto> {

        return Flowable.fromCallable {
            val response = AtomicReference<ServerListDto>()
            val throwable = AtomicReference<Throwable>()

            dataSource.gerServerList(jsonParams).subscribe({ response.set(it) }, { throwable.set(it) })

            throwable.get()?.let {
                throw RuntimeException(it.localizedMessage)
            }

            return@fromCallable response.get()

        }

    }

}

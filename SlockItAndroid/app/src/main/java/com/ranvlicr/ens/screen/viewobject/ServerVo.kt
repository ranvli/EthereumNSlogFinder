package com.ranvlicr.ens.screen.viewobject

/**
 * ENS
 *
 * Created by Randall Vargas on 3/12/19.
 *
 */
class ServerVo private constructor(
    val blockHash: String, val blockNumber: Long, val noOfTransactions: Long,
    val timeStamp: Long
) : Comparable<Long> {

    companion object {

        @JvmStatic
        fun builder() = Builder()

    }

    override fun compareTo(other: Long): Int {
        if (timeStamp > other) return 1
        if (timeStamp < other) return -1
        return 0
    }

    class Builder {

        private var blockHash = ""
        private var blockNumber = -1L
        private var noOfTransactions = -1L
        private var timeStamp = -1L

        fun blockHash(value: String?) = apply {
            if (null != value) {
                this.blockHash = value
            }
        }

        fun blockNumber(value: Long?) = apply {
            if (null != value) {
                this.blockNumber = value
            }
        }

        fun noOfTransactions(value: Long?) = apply {
            if (null != value) {
                this.noOfTransactions = value
            }
        }

        fun timeStamp(value: Long?) = apply {
            if (null != value) {
                this.timeStamp = value
            }
        }

        fun build() = ServerVo(blockHash, blockNumber, noOfTransactions, timeStamp)

    }

}

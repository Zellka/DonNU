import kotlin.math.pow
import kotlin.math.sqrt

fun main(args: Array<String>) {
    println("1 задание")
    println("Машинный ноль для вещественного числа стандартной точности: " + getMachineZero(1F))
    println("Машинный ноль для вещественного числа повышенной точности: " + getMachineZero(1.0))
    println("Машинная бесконечность для вещественного числа стандартной точности: " + getMachineInfinity(1F, 1F))
    println("Машинная бесконечность для вещественного числа повышенной точности: " + getMachineInfinity(1.0, 1.0))

    println("\n2 задание")
    println("Без преобразований исходной формулы: " + getFirstEx(3.0))
    println("Расчёт факториала с числом n целого типа: " + getFirstEx(3.0))
    println("Расчёт факториала с числом n вещественного типа: " + getThirdEx(3.0))
    println("Расчет с вычислением очередного члена ряда через предыдущий член: " + getFourthEx(3.0))
}

fun getMachineZero(e: Double): Double {
    var machineZero = e
    while (machineZero / 2 > 0)
        machineZero /= 2
    return machineZero
}

fun getMachineZero(e: Float): Float {
    var machineZero = e
    while (machineZero / 2 > 0)
        machineZero /= 2
    return machineZero
}

fun getMachineInfinity(inf: Double, value: Double): Double {
    var infinity = inf
    var tmp = value
    while (true) {
        tmp *= 2
        if (tmp == Double.POSITIVE_INFINITY)
            break
        infinity = tmp
    }
    return infinity
}

fun getMachineInfinity(inf: Float, value: Float): Float {
    var infinity = inf
    var tmp = value
    while (true) {
        tmp *= 2
        if (tmp == Float.POSITIVE_INFINITY)
            break
        infinity = tmp
    }
    return infinity
}

fun getFirstEx(x: Double): Double {
    var sum = 0.0
    var n = 0
    while (true) {
        val term = (-1.0).pow(n) * x.pow(2 * n + 1) / getFactorial(n) * (2 * n + 1)
        if (term.isInfinite()) break
        sum += term
        n++
    }
    return 2 / sqrt(kotlin.math.PI) * sum
}

fun getThirdEx(x: Double): Double {
    var sum = 0.0
    var n = 0.0
    while (true) {
        val term = (-1.0).pow(n) * x.pow(2 * n + 1) / getFactorial(n) * (2 * n + 1)
        if (term.isInfinite()) break
        sum += term
        n++
    }
    return 2 / sqrt(kotlin.math.PI) * sum
}

fun getFactorial(n: Int): Int {
    var factorial = 1
    if (n == 0) return 1
    for (i in 1..n) factorial *= i
    return factorial
}

fun getFactorial(n: Double): Double {
    var factorial = 1.0
    if (n == 0.0) return 1.0 else {
        var i = 0
        while (i <= n) {
            factorial *= i.toDouble()
            i++
        }
    }
    return factorial
}

fun getFourthEx(x: Double): Double {
    var sum = 0.0
    var n = 1
    var previousTerm = x * -1
    while (true) {
        val k = getCoefficient(x, n)
        val term = k * previousTerm
        if (term == 0.0) break
        previousTerm = term
        sum += term
        n++
    }
    return 2 / sqrt(kotlin.math.PI) * sum
}

fun getCoefficient(x: Double, n: Int): Double {
    return -1 * x.pow(2) * (2 * n - 1) / (n * (2 * n + 1))
}



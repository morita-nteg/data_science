
import scala.math._

object input1Dim {
    def L(a : Double, y : Double) = -(y*log(a) + (1-y)*log(1-a))
    def sigmoid(w : Double, b : Double, x : Double) = 1.0 / (1.0 + exp(-(w*x+b)))
    def BackPropergation(trains : List[(Double, Double)]) = {
        var w = 0.0
        var b = 0.0
        var a = 0.0

        for (n <- 0 to 5000) {
            for (train <- trains) {
                val (x, y) = train
                a = sigmoid(w, b, x)
                w = w - 0.01 * (a - y) * x
                b = b - 0.01 * (a - y)
            }
        }

        println("w = " + w)
        println("b = " + b)
        (w,b)
    }
}
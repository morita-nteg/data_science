name := "ExportTimeSeries"

javacOptions ++= Seq("-source", "1.7", "-target", "1.7", "-Xlint")

version := "1.0"

scalaVersion := "2.11.12"

libraryDependencies ++= Seq(

    "org.apache.poi" % "poi" % "3.17",

    "org.apache.poi" % "poi-ooxml" % "3.17"

)


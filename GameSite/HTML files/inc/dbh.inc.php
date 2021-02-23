<?php

$dbServername = "localhost";
$dbUsername = "root";
$dbPassword = "";
$dbName = "signup_accounts";

$conn = mysqli_connect($dbServername, $dbUsername, $dbPassword, $dbName) or die("Could not connect to the database");

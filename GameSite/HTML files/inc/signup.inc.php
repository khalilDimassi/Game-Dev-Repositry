<?php
    include_once "dbh.inc.php";

    $username = $_POST["username"];
    $pwd = $_POST["password"];
    $mail = $_POST["email"];

    $sql = "INSERT INTO accounts 
                (userName, pass, email)
            VALUES
                ('$username', '$pwd', '$mail');";
                
    mysqli_query($conn, $sql);
    

    header("location: ../index.html?signup=success");
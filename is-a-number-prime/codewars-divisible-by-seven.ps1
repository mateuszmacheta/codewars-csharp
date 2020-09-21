function seven([long]$m) {
    $i = 0
    while ($m -ge 100) {
        $i++
        $m = [math]::Floor($m / 10) - 2 * ($m % 10)
        $m
    }
    return @($m, $i)
}

$x = seven 477557101
$x
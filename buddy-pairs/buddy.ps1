function Buddy($start, $lim) {

    $allNumbers = [System.Collections.ArrayList]@()
    function get-divisorsSum ($num) {
        # returns sum of proper divisors
        $sum = 1
        $sqrt = [math]::Sqrt($num)
        for ($i = 2; $i -lt $sqrt; $i++) {
            if ($num % $i -eq 0) {
                $sum += ($num / $i)
                $sum += $i
            }
        }
        if ($sqrt -eq [math]::Floor($sqrt))
        { $sum += $sqrt }
        return $sum
    }

    function find-second($secondNumber) {
        # finds if potentially second number (m) is in array of current numbers
        if ($secondNumber -gt $lim) # if its greater than the limit, it is not
        { return $null }
        for ($i = 0; $i -lt $numCount; $i++ ) {
            # here we know that is within our range, so we just need index
            if ($allNumbers[$i].Number -eq $secondNumber)
            { return $allNumbers[$i] }
        }
    }

    # populating list by numbers between start and lim, but only if sum of divisors (sum) is >= start + 1
    # otherwise we would have one buddy who is smaller than start, and that is forbidden
    foreach ($i in ($start..$lim)) {
        $entry = $i | Select-Object @{l = 'Number'; e = { $_ } }, @{l = 'Sum'; e = { (get-divisorsSum $_) } } #, @{l = 'Checked'; e = { $false } }
        if ($entry.Sum -ge ($start + 1)) 
        { $allNumbers.Add($entry) | Out-Null }
    } 
    $numCount = $allNumbers.Count

    # looping through all numbers and checking if their sum - 1 points to number from the list
    foreach ($i in (0..($numCount - 1))) {
        $first = $allNumbers[$i]
        # if the number is on the list then we check if that number's sum - 1 is our initial number
        if (($second = find-second ($first.Sum - 1)) -and ($second.Sum -eq $first.Number + 1)) {
            return '(' + $first.Number.toString() + ', ' + $second.Number.toString() + ')'
        }
        # if number is NOT on the list then we first need to calculate it's sum and then check the save
        $second = ($first.Sum - 1) | Select-Object @{l = 'Number'; e = { $_ } }, @{l = 'Sum'; e = { (get-divisorsSum $_) } }
        if ($second.Sum -eq $first.Number + 1)
        { return '(' + $first.Number.toString() + ', ' + $second.Number.toString() + ')' }
        <#$allNumbers.Add($entry) | Out-Null
        $second = $allNumbers[-1]
        if ($second.Sum -eq $first.Number + 1)
        { return '(' + $first.Number.toString() + ', ' + $second.Number.toString() + ')' }#>
    }
    # if nothing has been returned yet then we don't have buddy pair
    return 'Nothing'
}
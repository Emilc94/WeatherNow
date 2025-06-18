<script>
    // Datoetiketter, gjennomsnittlig temperatur og fuktighet per dag
    const labels = @Html.Raw(System.Text.Json.JsonSerializer.Serialize(dailyTemperatureData.Select(d => d.Date)));
    const temperatures = @Html.Raw(System.Text.Json.JsonSerializer.Serialize(dailyTemperatureData.Select(d => d.AverageTemperature)));
    const humidityData = @Html.Raw(System.Text.Json.JsonSerializer.Serialize(dailyHumidityData.Select(d => d.AverageHumidity)));
</script>

<script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
<script>
    // Temperaturgraf
    const tempCtx = document.getElementById('temperatureChart').getContext('2d');
    const temperatureChart = new Chart(tempCtx, {
        type: 'line',
        data: {
            labels: labels, // Felles datoer for temperatur
            datasets: [{
                label: 'Average Temperature (°C)',
                data: temperatures, // Gjennomsnittlig temperatur per dag
                borderColor: 'rgba(75, 192, 192, 1)',
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                fill: true,
            }]
        },
        options: {
            scales: {
                x: {
                    title: {
                        display: true,
                        text: 'Date'
                    }
                },
                y: {
                    title: {
                        display: true,
                        text: 'Temperature (°C)'
                    }
                }
            }
        }
    });

    // Fuktighetsgraf
    const humidityCtx = document.getElementById('humidityChart').getContext('2d');
    const humidityChart = new Chart(humidityCtx, {
        type: 'line',
        data: {
            labels: labels, // Felles datoer for fuktighet
            datasets: [{
                label: 'Average Humidity (%)',
                data: humidityData, // Gjennomsnittlig fuktighet per dag
                borderColor: 'rgba(54, 162, 235, 1)',
                backgroundColor: 'rgba(54, 162, 235, 0.2)',
                fill: true,
            }]
        },
        options: {
            scales: {
                x: {
                    title: {
                        display: true,
                        text: 'Date'
                    }
                },
                y: {
                    title: {
                        display: true,
                        text: 'Humidity (%)'
                    }
                }
            }
        }
    });
</script>

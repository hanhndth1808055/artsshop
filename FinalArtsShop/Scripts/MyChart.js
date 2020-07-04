$(function () {
    // Create the chart
    $('#container').highcharts('StockChart', {


        title: {
            text: 'AAPL Stock Price'
        },

        series: [{
            name: 'AAPL',
            data: [[1530538200000, 187.18], [1530624600000, 183.92], [1530797400000, 185.4], [1530883800000, 187.97], [1530893800000, 187.97]],
            tooltip: {
                valueDecimals: 2
            }
        }]

    }, function (chart) {

        // apply the date pickers
        setTimeout(function () {
            $('input.highcharts-range-selector', $(chart.container).parent())
                .datepicker();
        }, 0);
    });


});

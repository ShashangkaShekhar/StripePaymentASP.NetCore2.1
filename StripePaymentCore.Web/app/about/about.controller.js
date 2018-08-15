
templatingApp.controller('AboutController', ['$scope', '$http', function ($scope, $http) {
    $scope.title = "About Page";
    $scope.stripeReturn = null;
    var amount = 50 * 100;

    var handler = StripeCheckout.configure({
        key: 'pk_test_hSh8EsouT9mkVjzdmGjRxgSL',
        image: 'https://stripe.com/img/documentation/checkout/marketplace.png',
        token: function (token) {
            var stripedata = {
                stripeEmail: token.email,
                stripeToken: token.id,
                stripeAmount: amount
            }

            $http({
                method: 'POST',
                url: '/api/Values/Charge/',
                data: JSON.stringify(stripedata)
            }).then(function (response) {
                $scope.stripeReturn = response.data;
                console.log(response.data);
            }, function (error) {
                console.log(error);
            });
        }
    });

    $('#customButton').on('click', function (e) {
        handler.open({
            name: 'Shashangka',
            description: 'Stripe Payment Gateway',
            amount: amount,
            billingAddress: true
        });

        e.preventDefault();
    });

}]);

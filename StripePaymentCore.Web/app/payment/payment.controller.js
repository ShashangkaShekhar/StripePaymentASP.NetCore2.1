templatingApp.controller('PaymentController', ['$scope', '$http', function ($scope, $http) {
    $scope.title = "Stripe Payment";
    $scope.stripeReturn = null;
    $scope.cartAmount = 50;

    var amount = ($scope.cartAmount * 100);

    var handler = StripeCheckout.configure({
        key: 'pk_test_hSh8EsouT9mkVjzdmGjRxgSL',
        image: 'https://stripe.com/img/documentation/checkout/marketplace.png',
        token: function (token) {
            var stripedata = {
                stripeEmail: token.email,
                stripeToken: token.id,
                stripeAmount: $scope.cartAmount
            }

            $http({
                method: 'POST',
                url: '/api/Values/Charge/',
                data: JSON.stringify(stripedata)
            }).then(function (response) {
                $scope.stripeReturn = "Payment " + response.data;
                //console.log(response.data);
            }, function (error) {
                console.log(error);
            });
        }
    });

    $('#paynow').on('click', function (e) {
        handler.open({
            name: 'Shashangka',
            description: 'Stripe Payment Gateway',
            amount: amount,
            billingAddress: true
        });

        e.preventDefault();
    });

}]);

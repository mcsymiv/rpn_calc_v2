# rpn_calc_v2

System Under Test - SUT

Это объекты, которые создаются и используются взамен реальных объектов, 
с которым взаимодействует тестируемый объект в процессе своей работы.

Stub

Stubs - обеспечивают жестко зашитый ответ на вызовы во время тестирования. 
Применяются для замены тех объектов, которые обеспечивают SUT входными данными. 
Также они могут сохранять в себе информацию о вызове (например параметры или 
количество этих вызовов) - такие иногда называют своим термином Test Spy. 
Такая "запись" позволяет оценить работу SUT, если состояние самого SUT не меняется.

Проверяет правильную работоспособность тестируемого объекта 
заключается в оценке состояния самого этого объекта, 
а также взаимодействующих объектов, после вызова этого метода.
{
Class under test <------------------> Sub
|                    Communicate
|
|
|     Assert
|
|
Test
}
// пример
[Test]
public void LogIn_ExisingUser_HashReturned()
{
	// Arrange
	OrderProcessor = Mock.Of<IOrderProcessor>();
	OrderData = Mock.Of<IOrderData>();
	LayoutManager = Mock.Of<ILayoutManager>();
	NewsProvider = Mock.Of<INewsProvider>();

	Service = new IosService(
		UserManager,
		AccountData,
		OrderProcessor,
		OrderData,
		LayoutManager,
		NewsProvider);
	
	// Act
	var hash = Service.LogIn("ValidUser", "Password");

	// Assert
	Assert.That(!string.IsNullOrEmpty(hash));
}

Mock

Mocks - объекты, которые настраиваются (например специфично каждому тесту) 
и позволяют задать ожидания в виде своего рода спецификации вызовов, которые 
мы планируем получить. Проверки соответствия ожиданиям проводятся через 
вызовы к Mock-объекту.

Проверяет набор и порядок действий (вызовов методов взаимодействующих 
объектов, других методов тестируемого объекта), которое должен совершить 
метод этот объект.
{
Class under test <------------------> Mock
                     Communicate    |
                                    |
                                    | Assert
                                    |
                                    |
                                  Test
}
// пример из https://habr.com/ru/post/169381/
[Test]
public void Create_AddAccountToSpecificUser_AccountCreatedAndAddedToUser()
{
    // Arrange
    var account = Mock.Of<AccountViewModel>();
            
    // Act
    _controller.Create(1, account);

    // Assert
    _accountData.Verify(m => m.CreateAccount(It.IsAny<IAccount>()), Times.Exactly(1));
    _accountData.Verify(m => m.AddAccountToUser(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
}
      
Stub vs Mock

стаб ничего не проверяет, а лишь имитирует заданное состояние. 
А мок — это объект, у которого есть ожидания. 
Например, что данный метод класса должен быть вызван определенное число раз.

Тест никогда не сломается из-за стаба, а вот из-за мока может.

С технической точки зрения это значит, что, используя стабы, 
мы проверяем состояние тестируемого класса или результат выполненного метода. 
При использовании мока мы проверяем, соответствуют ли ожидания мока 
поведению тестируемого класса. Также лучше использовать не более одного мока на тест. 
Иначе с высокой вероятностью вы нарушите принцип «тестировать только одну вещь». 




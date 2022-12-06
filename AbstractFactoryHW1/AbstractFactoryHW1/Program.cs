using AbstractFactoryHW1;

ICountryFactory factory = new EnglandFactory();
ICountry country = factory.CreateCountry();
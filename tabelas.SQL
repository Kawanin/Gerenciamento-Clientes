CREATE TABLE ClienteResidencial (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100),
    Telefone VARCHAR(20)
);

CREATE TABLE Obra (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(255),
    Endereco VARCHAR(255)
);

CREATE TABLE Condominio (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100),
    Endereco VARCHAR(255)
);

CREATE TABLE Edificio (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100),
    Endereco VARCHAR(255)
);

CREATE TABLE UnidadeResidencial (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Tipo VARCHAR(50),
    Numero INT,
    ObraID INT,
    CondominioID INT,
    EdificioID INT,
    DataEntrega DATE,
    FOREIGN KEY (ObraID) REFERENCES Obra(ID),
    FOREIGN KEY (CondominioID) REFERENCES Condominio(ID),
    FOREIGN KEY (EdificioID) REFERENCES Edificio(ID)
);

CREATE TABLE ChamadoManutencao (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    UnidadeResidencialID INT,
    DescricaoProblema TEXT,
    DataAbertura DATETIME,
    DataPrimeiroContato DATETIME,
    Status ENUM('ClienteNotificaProblema', 'EquipeFazVistoriaInicial', 'RetornoCliente', 'ManutencaoEmAndamento', 'ManutencaoFinalizada'),
    MotivoNaoRealizacao VARCHAR(255),
    EmpreiteirosNecessarios VARCHAR(255),
    FOREIGN KEY (UnidadeResidencialID) REFERENCES UnidadeResidencial(ID)
);

CREATE TABLE EquipeManutencao (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100)
);

CREATE TABLE LiderEquipe (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    EquipeID INT,
    NomeResponsavel VARCHAR(100),
    FOREIGN KEY (EquipeID) REFERENCES EquipeManutencao(ID)
);

CREATE TABLE Empreiteiro (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Nome VARCHAR(100)
);

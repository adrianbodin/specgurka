# language: sv
Egenskap: hantera anställda

Som HR-chef
Vill jag lägga till, uppdatera och ta bort anställda i avdelningar så att personaluppgifter är korrekta och uppdaterade i företaget

  Bakgrund:

  Detta gäller för **alla** scenarier under.
  Superviktigt.

    Givet att jag är inloggad som HR-chef
    Och att jag är på sidan "Hantera anställda"

  Scenario: Lägg till en ny anställd till en avdelning

  Testar om detta *fungerar*.

    Givet att avdelningen "Teknologi" finns med följande anställda:
      | Namn       | Roll       |
      | Jane Doe   | Engineer   |
      | John Smith | Contractor |
    När jag lägger till en anställd "John Doe" med rollen "Engineer" till avdelningen "Teknologi"
    Så ska "John Doe" läggas till i listan över anställda i avdelningen "Teknologi"

  Scenario: Ta bort en anställd från en avdelning
    Givet att en anställd "John Doe" finns i avdelningen "Teknologi"
    När jag tar bort "John Doe" från avdelningen "Teknologi"
    Så ska "John Doe" inte längre visas i listan över anställda i avdelningen "Teknologi"